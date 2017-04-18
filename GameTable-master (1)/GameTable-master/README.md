# GameTable

##시스템 권장 사항
  - Python 3.5 이상

##폴더 구조

  - GameTable-Converter
    - Converter
      - xlrd -> Python 라이브러리 폴더입니다.
      - excel2table.py -> 컨버터 코어 스크립트 입니다.
      - convert.py -> EXCEL_PATH, JSON_PATH변수로 실제 컨버트를 하는 스크립트 입니다.
    - Excel -> 변환할 Excel파일이 위치합니다.
    - Json -> 변환된 Json파일이 위치합니다.
    - run.bat -> convert.py의 바로가기 입니다.
    
  - GameTable-TableSystem
    - Core
      - BaseDescriptor.cs -> Descriptor의 기본이 되는 클래스 입니다. 
      - GenericTable.cs -> Table의 기본이 되는 제너릭 클래스 입니다.
      - Editor
        - TablePostprocessor.cs -> Excel파일에 변경이 있을경우 run.bat을 실행해주는 클래스입니다.
    - Plugins -> TableSystem에 필요한 라이브러리 폴더입니다.
  
  - GameTable-Unity -> Convert와 TableSystem을 사용하는 유니티 샘플입니다.
