namespace Print.bean
{
    class ExcelTemplateBean
    {
        //-1 null 0 原值 1域值 2列表值
        private int valueType;
        private int rowIndex;
        private int columnIndex;
        private string fieldId;
        private string fieldName;

        public ExcelTemplateBean(int valueType)
        {
            this.ValueType = valueType;
        }

        public ExcelTemplateBean(int valueType, string fieldName)
        {
            this.ValueType = valueType;
            this.FieldName = fieldName;
        }

        public ExcelTemplateBean(int valueType, string fieldId, string fieldName)
        {
            this.ValueType = valueType;
            this.FieldId = fieldId;
            this.FieldName = fieldName;
        }

        public int ValueType
        {
            get
            {
                return valueType;
            }

            set
            {
                valueType = value;
            }
        }

        public int RowIndex
        {
            get
            {
                return rowIndex;
            }

            set
            {
                rowIndex = value;
            }
        }

        public int ColumnIndex
        {
            get
            {
                return columnIndex;
            }

            set
            {
                columnIndex = value;
            }
        }

        public string FieldId
        {
            get
            {
                return fieldId;
            }

            set
            {
                fieldId = value;
            }
        }

        public string FieldName
        {
            get
            {
                return fieldName;
            }

            set
            {
                fieldName = value;
            }
        }
    }
}
