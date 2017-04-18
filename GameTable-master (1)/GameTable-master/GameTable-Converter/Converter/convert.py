import sys
import os
from excel2table import Converter

# Need python ver 3.5 or later
REQUIRE_VERSION = (2, 7)

# File path
EXCEL_PATH = '../Excel/'
JSON_PATH = '../Json/'

# Get current python version
current_version = sys.version_info

# Check version
if current_version < REQUIRE_VERSION:
    print('You Need Python 3.5 or later')
    input()
    sys.exit()

converter = Converter(True, JSON_PATH)
    
for path, dirs, files in os.walk(EXCEL_PATH):
    for file in files:
        if file[0] is "~":
            continue
        
        if os.path.splitext(file)[1].lower() == '.xlsx':
            converter.convert(EXCEL_PATH + file)
            
            
#Assets\TableSystem\Resources\JsonTable
