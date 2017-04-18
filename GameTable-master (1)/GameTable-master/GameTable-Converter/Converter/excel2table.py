import xlrd
import os
import copy
import json
import codecs
from collections import OrderedDict

PARENT_NAME_ROW = 0
PARENT_NAME_COL = 0
COLUMN_NAMES_ROW = 1
DATA_STARTING_ROW = 2
ROOT_NAME = '*root'
ID_COLUMN_NAME = 'id'
PARENT_COLUMN_NAME = '*parent'
IGNORE_WILDCARD = '_'


class TypeUtility:
    # xlrd is giving number as float

    @staticmethod
    def check_integer(value):
        return type(value) == float and int(value) == value

    # xlrd is giving boolean as integer
    @staticmethod
    def check_boolean(value):
        return type(value) == int

    @staticmethod
    def convert_value(value):
        if TypeUtility.check_integer(value):
            return int(value)
        elif TypeUtility.check_boolean(value):
            return bool(value)
        else:
            return value


class Table:

    def __init__(self, sheet):
        self.init_name(sheet)
        self.init_parent_name(sheet)
        self.init_metadata(sheet)
        self.init_descriptors(sheet)
        self.init_id_index_map()

    def init_name(self, sheet):
        self.name = sheet.name

    def init_parent_name(self, sheet):
        row = sheet.row_values(PARENT_NAME_ROW)
        self.parent_name = row[PARENT_NAME_COL]
        if type(self.parent_name) is not str:
            raise Exception('Parent name is not string')

        self.is_root = self.parent_name == ROOT_NAME

    def init_metadata(self, sheet):
        row = sheet.row_values(COLUMN_NAMES_ROW)
        self.is_parent = False
        self.is_child = False
        self.column_names = []
        for value in row:
            if type(value) is not str:
                raise Exception('Column name is not string')

            if value == ID_COLUMN_NAME:
                self.is_parent = True
            if value == PARENT_COLUMN_NAME:
                self.is_child = True
            self.column_names.append(value)

        if self.is_root and self.is_child:
            raise Exception('Root table must not have "' +
                            PARENT_COLUMN_NAME + '" column')

        if not self.is_root and not self.is_child:
            raise Exception('Child table must have "' +
                            PARENT_COLUMN_NAME + '" column')

    def init_descriptors(self, sheet):
        self.descriptors = []
        for i in range(DATA_STARTING_ROW, sheet.nrows):
            col = sheet.row_values(i)
            self.descriptors.append(self.get_descriptor(col))

    def get_descriptor(self, col):
        descriptor = OrderedDict()
        for i in range(0, len(col)):
            key = self.column_names[i]
            if key[0] == IGNORE_WILDCARD:
                continue

            descriptor[key] = TypeUtility.convert_value(col[i])

        return descriptor

    def init_id_index_map(self):
        if not self.is_parent:
            return

        self.id_index_map = {}
        for descriptor in self.descriptors:
            id = descriptor[ID_COLUMN_NAME]
            self.id_index_map[id] = self.descriptors.index(descriptor)

    def merge_child_table(self, table):
        self.add_child_descriptor_list(table.name)
        for descriptor in table.descriptors:
            parent_id = descriptor[PARENT_COLUMN_NAME]
            parent_idx = self.id_index_map[parent_id]
            parent_descriptor = self.descriptors[parent_idx]
            parent_descriptor[table.name].append(descriptor)

    def add_child_descriptor_list(self, name):
        for descriptor in self.descriptors:
            descriptor[name] = []

    def remove_parent_column(self):
        for descriptor in self.descriptors:
            del descriptor[PARENT_COLUMN_NAME]

    def save_to_json(self, pretty_print, export_path):
        if pretty_print:
            string = json.dumps(self.descriptors, ensure_ascii=False, indent=4)
        else:
            string = json.dumps(self.descriptors, ensure_ascii=False)

        with codecs.open(export_path + self.name + '.json', 'w', 'utf-8') as f:
            f.write(string)


class Converter:

    def __init__(self, pretty_print, export_path):
        self.pretty_print = pretty_print
        self.export_path = export_path

    def convert(self, filename):
        only_filename = filename.split('/')

        print(only_filename[-1] + ' convert starting...')

        sheets = Converter.get_sheets(filename)
        root_table, tables = Converter.get_tables(sheets)
        Converter.post_process(tables)
        root_table.save_to_json(self.pretty_print, self.export_path)

        print(only_filename[-1] + ' convert is Done\n')

    @staticmethod
    def get_sheets(filename):
        path = os.path.abspath(filename)
        workbook = xlrd.open_workbook(path)
        return workbook.sheets()

    @staticmethod
    def get_tables(sheets):
        tables = {}
        root_tables = []

        for sheet in sheets:
            if sheet.name[0] == IGNORE_WILDCARD:
                continue

            table = Table(sheet)
            tables[table.name] = table
            if table.is_root:
                root_tables.append(table)

        if len(root_tables) == 1:
            return root_tables[0], tables
        else:
            raise Exception('Root table must be one')

    @staticmethod
    def post_process(tables):
        for name, table in tables.items():
            if table.is_root:
                continue

            parent_table = tables[table.parent_name]
            if not parent_table.is_parent:
                raise Exception('Parent table must have id column')

            parent_table.merge_child_table(table)
            table.remove_parent_column()
