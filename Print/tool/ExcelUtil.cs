using common.tool;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Print.bean;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Print.tool
{
    class ExcelUtil
    {
        /**
         * 年月日时分秒 默认格式
         */
        private static string COMMON_DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        /**
         * 时间 默认格式
         */
        private static string COMMON_TIME_FORMAT = "HH:mm:ss";
        /**
         * 年月日 默认格式
         */
        private static string COMMON_DATE_FORMAT_NYR = "yyyy-MM-dd";
        /**
         * 年月 默认格式
         */
        private static string COMMON_DATE_FORMAT_NY = "yyyy-MM";
        /**
         * 月日 默认格式
         */
        private static string COMMON_DATE_FORMAT_YR = "MM-dd";
        /**
         * 月 默认格式
         */
        private static string COMMON_DATE_FORMAT_Y = "MM";
        /**
         * 星期 默认格式
         */
        private static string COMMON_DATE_FORMAT_XQ = "星期";
        /**
         * 周 默认格式
         */
        private static string COMMON_DATE_FORMAT_Z = "周";
        /**
         * 07版时间(非日期) 总time
         */
        private static List<short> EXCEL_FORMAT_INDEX_07_TIME = new List<short>(
                new short[] { 18, 19, 20, 21, 32, 33, 45, 46, 47, 55, 56, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186 }
        );
        /**
         * 07版日期(非时间) 总date
         */
        private static List<short> EXCEL_FORMAT_INDEX_07_DATE = new List<short>(
                new short[]{14, 15, 16, 17, 22, 30, 31, 57, 58, 187, 188, 189, 190, 191, 192, 193,
                    194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208}
        );
        /**
         * 03版时间(非日期) 总time
         **/
        private static List<short> EXCEL_FORMAT_INDEX_03_TIME = new List<short>(
                new short[] { 18, 19, 20, 21, 32, 33, 45, 46, 47, 55, 56, 176, 177, 178, 179, 180, 181, 182, 183, 184, 185, 186 }
        );
        /**
         * 03版日期(非日期) 总date
         */
        private static List<short> EXCEL_FORMAT_INDEX_03_DATE = new List<short>(
                new short[]{14, 15, 16, 17, 22, 30, 31, 57, 58, 187, 188, 189, 190, 191, 192, 193,
                    194, 195, 196, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208}
        );
        /**
         * date-年月日时分秒
         **/
        private static List<string> EXCEL_FORMAT_INDEX_DATE_NYRSFM_STRING = new List<string>(
                new string[] { "yyyy/m/d\\ h:mm;@", "m/d/yy h:mm", "yyyy/m/d\\ h:mm\\ AM/PM",
                "[$-409]yyyy/m/d\\ h:mm\\ AM/PM;@", "yyyy/mm/dd\\ hh:mm:dd",
                "yyyy/mm/dd\\ hh:mm", "yyyy/m/d\\ h:m", "yyyy/m/d\\ h:m:s",
                "yyyy/m/d\\ h:mm", "m/d/yy h:mm;@", "yyyy/m/d\\ h:mm\\ AM/PM;@" }
        );
        /**
         * date-年月日
         */
        private static List<string> EXCEL_FORMAT_INDEX_DATE_NYR_STRING = new List<string>(
                new string[] {
                "m/d/yy", "[$-F800]dddd\\,\\ mmmm\\ dd\\,\\ yyyy", "[DBNum1][$-804]yyyy\"年\"m\"月\"d\"日\";@",
                "yyyy\"年\"m\"月\"d\"日\";@", "yyyy/m/d;@", "yy/m/d;@", "m/d/yy;@", "[$-409]d/mmm/yy", "[$-409]dd/mmm/yy;@",
                "reserved-0x1F", "reserved-0x1E", "mm/dd/yy;@", "yyyy/mm/dd", "d-mmm-yy", "[$-409]d\\-mmm\\-yy;@",
                "[$-409]d\\-mmm\\-yy", "[$-409]dd\\-mmm\\-yy;@", "[$-409]dd\\-mmm\\-yy", "[DBNum1][$-804]yyyy\"年\"m\"月\"d\"日\"",
                "yy/m/d", "mm/dd/yy", "dd\\-mmm\\-yy" }
        );
        /**
         * date-年月
         */
        private static List<string> EXCEL_FORMAT_INDEX_DATE_NY_STRING = new List<string>(
                new string[] {
                "[DBNum1][$-804]yyyy\"年\"m\"月\";@", "[DBNum1][$-804]yyyy\"年\"m\"月\"",
                "yyyy\"年\"m\"月\";@", "yyyy\"年\"m\"月\"", "[$-409]mmm\\-yy;@", "[$-409]mmm\\-yy",
                "[$-409]mmm/yy;@", "[$-409]mmm/yy", "[$-409]mmmm/yy;@", "[$-409]mmmm/yy",
                "[$-409]mmmmm/yy;@", "[$-409]mmmmm/yy", "mmm-yy", "yyyy/mm", "mmm/yyyy",
                "[$-409]mmmm\\-yy;@", "[$-409]mmmmm\\-yy;@", "mmmm\\-yy", "mmmmm\\-yy" }
        );
        /**
         * date-月日
         */
        private static List<string> EXCEL_FORMAT_INDEX_DATE_YR_STRING = new List<string>(
                new string[] {
                "[DBNum1][$-804]m\"月\"d\"日\";@", "[DBNum1][$-804]m\"月\"d\"日\"",
                "m\"月\"d\"日\";@", "m\"月\"d\"日\"", "[$-409]d/mmm;@", "[$-409]d/mmm",
                "m/d;@", "m/d", "d-mmm", "d-mmm;@", "mm/dd", "mm/dd;@", "[$-409]d\\-mmm;@", "[$-409]d\\-mmm" }
        );
        /**
         * date-星期X
         */
        private static List<string> EXCEL_FORMAT_INDEX_DATE_XQ_STRING = new List<string>(
                new string[] { "[$-804]aaaa;@", "[$-804]aaaa" });
        /**
         * date-周X
         */
        private static List<string> EXCEL_FORMAT_INDEX_DATE_Z_STRING = new List<string>(
                new string[] { "[$-804]aaa;@", "[$-804]aaa" });
        /**
         * date-月X
         */
        private static List<string> EXCEL_FORMAT_INDEX_DATE_Y_STRING = new List<string>(
                new string[] { "[$-409]mmmmm;@", "mmmmm", "[$-409]mmmmm" });
        /**
         * time - 时间
         */
        private static List<string> EXCEL_FORMAT_INDEX_TIME_STRING = new List<string>(
                new string[] {
                "mm:ss.0", "h:mm", "h:mm\\ AM/PM", "h:mm:ss", "h:mm:ss\\ AM/PM",
                "reserved-0x20", "reserved-0x21", "[DBNum1]h\"时\"mm\"分\"", "[DBNum1]上午/下午h\"时\"mm\"分\"", "mm:ss",
                "[h]:mm:ss", "h:mm:ss;@", "[$-409]h:mm:ss\\ AM/PM;@", "h:mm;@", "[$-409]h:mm\\ AM/PM;@",
                "h\"时\"mm\"分\";@", "h\"时\"mm\"分\"\\ AM/PM;@", "h\"时\"mm\"分\"ss\"秒\";@", "h\"时\"mm\"分\"ss\"秒\"_ AM/PM;@", "上午/下午h\"时\"mm\"分\";@",
                "上午/下午h\"时\"mm\"分\"ss\"秒\";@", "[DBNum1][$-804]h\"时\"mm\"分\";@", "[DBNum1][$-804]上午/下午h\"时\"mm\"分\";@", "h:mm AM/PM", "h:mm:ss AM/PM",
                "[$-F400]h:mm:ss\\ AM/PM" }
        );
        /**
         * date-当formatString为空的时候-年月
         */
        private static short EXCEL_FORMAT_INDEX_DATA_EXACT_NY = 57;
        /**
         * date-当formatString为空的时候-月日
         */
        private static short EXCEL_FORMAT_INDEX_DATA_EXACT_YR = 58;
        /**
         * time-当formatString为空的时候-时间
         */
        private static List<short> EXCEL_FORMAT_INDEX_TIME_EXACT = new List<short>(new short[] { 55, 56 });
        /**
         * 格式化星期或者周显示
         */
        private static string[] WEEK_DAYS = { "日", "一", "二", "三", "四", "五", "六" };

        private static Regex fieldRegex = new Regex("^f\\{(\\w+)\\}$");
        private static Regex ListRegex = new Regex("^f\\{(\\w+)\\}\\{(\\w+)\\}$");

        private List<ExcelTemplateBean> fieldList = null;
        private IDictionary<string, List<ExcelTemplateBean>> dicList = null;

        public ExcelUtil()
        {

        }

        public string TemplateExport(string templateFileNameAndExtension, string exportOutFileName,
            IDictionary<string, string> fixedField, IDictionary<string, DataTable> listField)
        {
            IWorkbook workbook = null;
            FileStream inFileStream = null;
            FileStream outFileStream = null;
            try
            {
                if ((fixedField != null && fixedField.Count > 0))
                {
                    fieldList = new List<ExcelTemplateBean>(fixedField.Count);
                }
                if ((listField != null && listField.Count > 0))
                {
                    dicList = new Dictionary<string, List<ExcelTemplateBean>>(listField.Count);
                }
                if (fieldList == null && dicList == null)
                {
                    return null;
                }
                string fileDir = Application.StartupPath;
                string fileName = fileDir + Path.DirectorySeparatorChar + "resource"
                    + Path.DirectorySeparatorChar + "template" + Path.DirectorySeparatorChar + templateFileNameAndExtension;
                //Console.WriteLine("模板文件路径："+fileName);
                inFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                string extension = Path.GetExtension(fileName);
                //if (".xlsx".Equals(extension))
                //{
                //    workbook = new XSSFWorkbook(inFileStream);
                //}
                //else if (".xls".Equals(extension))
                //{
                //    workbook = new HSSFWorkbook(inFileStream);
                //}
                //else
                //{
                //    return null;
                //}
                if (!".xls".Equals(extension) && !".xlsx".Equals(extension))
                {
                    return null;
                }
                workbook = WorkbookFactory.Create(inFileStream);
                ScanField(workbook);

                ISheet sheet = workbook.GetSheetAt(0);
                IRow row = null;
                ICell cell = null;
                string cellValue = null;
                string regex = null;
                string fieldValue = null;
                //写固定字段
                if (fieldList != null)
                {
                    foreach (ExcelTemplateBean bean in fieldList)
                    {
                        row = sheet.GetRow(bean.RowIndex);
                        cell = row.GetCell(bean.ColumnIndex);
                        if (cell == null)
                        {
                            continue;
                        }
                        cellValue = cell.ToString();
                        regex = "f{" + bean.FieldName + "}";
                        if (CheckTools.isNull(cellValue))
                        {
                            cellValue = regex;
                        }
                        if (fixedField.ContainsKey(bean.FieldName))
                        {
                            fieldValue = fixedField[bean.FieldName];
                        }
                        else
                        {
                            fieldValue = null;
                        }
                        if (fieldValue == null)
                        {
                            fieldValue = "";
                        }
                        cell.SetCellValue(cellValue.Replace(regex, fieldValue));
                    }
                }
                //写列表字段
                if (dicList != null)
                {
                    int realInsertedRows = 0;
                    string listId;
                    DataTable dataTable = null;
                    List<ExcelTemplateBean> beanList;
                    foreach (KeyValuePair<string, List<ExcelTemplateBean>> pair in dicList)
                    {
                        listId = pair.Key;
                        beanList = pair.Value;
                        //List<ExcelTemplateBean>属于同一行数据
                        if (listField.ContainsKey(listId))
                        {
                            dataTable = listField[listId];
                        }
                        else
                        {
                            dataTable = new DataTable();
                            //创建空行
                            DataRow dr = dataTable.NewRow();
                            dataTable.Rows.Add(dr);
                            foreach (ExcelTemplateBean bean in beanList)
                            {
                                //动态添加列
                                dataTable.Columns.Add(bean.FieldName, typeof(string));
                                //通过列名赋值
                                dr[bean.FieldName] = "";
                            }
                        }
                        int minRowIndex = MinRowIndex(beanList);
                        if (minRowIndex == -1 || minRowIndex == int.MaxValue)
                        {
                            continue;
                        }
                        int templateStartRowIndex = minRowIndex + realInsertedRows;//计算变化后的起码索引号
                        int NumInsertedRows = dataTable.Rows.Count - 1;//少插入一行，模板自身占了一行
                        int realInsertingRows = InsertRows(sheet, templateStartRowIndex, NumInsertedRows);//本次插入的实际行数
                        int multipleInserted = NumInsertedRows == 0 ? 0 : (realInsertingRows / NumInsertedRows);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            DataRow dr = dataTable.Rows[i];
                            foreach (ExcelTemplateBean bean in beanList)
                            {
                                row = sheet.GetRow(bean.RowIndex + realInsertedRows + i * multipleInserted);
                                cell = row.GetCell(bean.ColumnIndex);//列不变
                                if (cell == null)
                                {
                                    continue;
                                }
                                cellValue = cell.ToString();
                                regex = "f{" + bean.FieldId + "}{" + bean.FieldName + "}";
                                if (CheckTools.isNull(cellValue))
                                {
                                    cellValue = regex;
                                }
                                if (dr.Table.Columns.Contains(bean.FieldName) && dr[bean.FieldName] != null)
                                {
                                    fieldValue = dr[bean.FieldName].ToString();
                                }
                                else
                                {
                                    fieldValue = null;
                                }
                                if (fieldValue == null)
                                {
                                    fieldValue = "";
                                }
                                cell.SetCellValue(cellValue.Replace(regex, fieldValue));
                            }
                        }
                        realInsertedRows += realInsertingRows;//多数据模板行时累加插入的实际行数
                    }
                }

                string outFileName = fileDir + Path.DirectorySeparatorChar + "resource"
                    + Path.DirectorySeparatorChar + "export" + Path.DirectorySeparatorChar
                    + DateTime.Now.ToString("yyyy-MM-dd") + Path.DirectorySeparatorChar + exportOutFileName + extension;
                string parentPath = Path.GetDirectoryName(outFileName);
                if (false == Directory.Exists(parentPath))
                {
                    //创建pic文件夹
                    Directory.CreateDirectory(parentPath);
                }
                outFileStream = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
                workbook.Write(outFileStream);
                outFileStream.Flush();

                return outFileName;
            }
            finally
            {
                if (inFileStream != null)
                {
                    inFileStream.Close();
                }
                if (outFileStream != null)
                {
                    outFileStream.Close();
                }
                if (workbook != null)
                {
                    workbook.Close();
                }
            }

        }

        private int MinRowIndex(List<ExcelTemplateBean> beanList)
        {
            if (beanList == null)
            {
                return -1;
            }
            int min = int.MaxValue;
            foreach (ExcelTemplateBean bean in beanList)
            {
                min = Math.Min(min, bean.RowIndex);
            }
            return min;
        }

        private void ScanField(IWorkbook workbook)
        {
            if (workbook == null)
            {
                return;
            }

            ISheet sheet = workbook.GetSheetAt(0);
            int rs = sheet.FirstRowNum;
            int re = sheet.LastRowNum;
            int cs = -1;
            int ce = -1;
            IRow row = null;
            ICell cell = null;
            string cellValue = null;
            for (int i = rs; i <= re; i++)
            {
                row = sheet.GetRow(i);
                if (row == null)
                {
                    continue;
                }
                cs = row.FirstCellNum;
                ce = row.LastCellNum;
                for (int j = cs; j < ce; j++)
                {
                    cell = row.GetCell(j);
                    if (cell == null)
                    {
                        continue;
                    }
                    cellValue = cell.ToString();
                    ExcelTemplateBean bean = CellValueRegex(cellValue);
                    if (bean.ValueType == -1 || bean.ValueType == 0)
                    {
                        continue;
                    }
                    bean.RowIndex = i;
                    bean.ColumnIndex = j;
                    switch (bean.ValueType)
                    {
                        case 1:
                            {
                                fieldList.Add(bean);
                                break;
                            }
                        case 2:
                            {
                                if (!dicList.ContainsKey(bean.FieldId))
                                {
                                    dicList[bean.FieldId] = new List<ExcelTemplateBean>();
                                }
                                dicList[bean.FieldId].Add(bean);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
        }

        private ExcelTemplateBean CellValueRegex(string cellValue)
        {
            if (CheckTools.isNull(cellValue))
            {
                return new ExcelTemplateBean(-1);
            }
            cellValue = cellValue.Trim();
            string fieldId = null;
            string fieldName = null;
            Match match = fieldRegex.Match(cellValue);
            if (match.Success)
            {
                fieldName = match.Groups[1].Value;
                //Console.WriteLine(fieldName);
                return new ExcelTemplateBean(1, fieldName);
            }
            match = ListRegex.Match(cellValue);
            if (match.Success)
            {
                fieldId = match.Groups[1].Value;
                fieldName = match.Groups[2].Value;
                return new ExcelTemplateBean(2, fieldId, fieldName);
            }
            return new ExcelTemplateBean(0);
        }

        public int InsertRows(ISheet sheet, int templateStartRowIndex, int insertedRows)
        {
            if (insertedRows == 0)
            {
                return 0;
            }
            //判断模板行是不是合并单元行
            int mergeRows = IsMergeRow(sheet, templateStartRowIndex);
            mergeRows = (mergeRows + 1);
            //实际应插入的行数
            int realInsertedRows = insertedRows * mergeRows;
            //templateStartRowIndex为模板行自身索引
            int endRowIndex = templateStartRowIndex + realInsertedRows;
            //插入行
            sheet.ShiftRows(templateStartRowIndex, sheet.LastRowNum, realInsertedRows, true, false);
            for (int i = 0; i < realInsertedRows; i++)
            {
                for (int mergeLoop = 0; mergeLoop < mergeRows; mergeLoop++)
                {
                    //获取模板行
                    IRow templateRow = sheet.GetRow(endRowIndex + mergeLoop);
                    if (templateRow == null)
                    {
                        sheet.CreateRow(templateStartRowIndex);
                        continue;
                    }
                    ICellStyle rowStyle = templateRow.RowStyle;
                    short rowHeight = templateRow.Height;

                    IRow insertedRow = sheet.CreateRow(templateStartRowIndex);
                    if (rowStyle != null)
                    {
                        insertedRow.RowStyle = rowStyle;
                    }
                    insertedRow.Height = rowHeight;
                    for (int j = templateRow.FirstCellNum; j < templateRow.LastCellNum; j++)
                    {
                        ICell templateCell = templateRow.GetCell(j);
                        ICell insertedCell = insertedRow.CreateCell(j);
                        if (templateCell != null)
                        {
                            ICellStyle cellStyle = templateCell.CellStyle;
                            if (cellStyle != null)
                            {
                                insertedCell.CellStyle = cellStyle;
                            }
                            CopyCellValue(templateCell, insertedCell);
                        }
                    }
                }
                CopyMergeRow(sheet, endRowIndex, endRowIndex + mergeRows, templateStartRowIndex);
                templateStartRowIndex++;
            }

            return realInsertedRows;
        }

        public int IsMergeRow(ISheet sheet, int sourceRowIdex)
        {
            int mergeRows = 0;
            CellRangeAddress region = null;
            for (int i = 0; i < sheet.NumMergedRegions; i++)
            {
                region = sheet.GetMergedRegion(i);
                if (region == null)
                {
                    continue;
                }
                if (region.FirstRow == sourceRowIdex)
                {
                    mergeRows = Math.Max(region.LastRow - region.FirstRow, mergeRows);
                }
            }
            return mergeRows;
        }

        public void CopyMergeRow(ISheet sheet, int sourceMergeRowStartIndex, int sourceMergeRowEndIndex, int targerMergeRowStartIndex)
        {
            int targetRowFrom;
            int targetRowTo;
            CellRangeAddress sourceRegion = null;
            for (int i = 0; i < sheet.NumMergedRegions; i++)
            {
                sourceRegion = sheet.GetMergedRegion(i);
                if (sourceRegion == null)
                {
                    continue;
                }
                if (sourceRegion.FirstRow >= sourceMergeRowStartIndex && sourceRegion.LastRow <= sourceMergeRowEndIndex)
                {
                    targetRowFrom = targerMergeRowStartIndex + (sourceRegion.FirstRow - sourceMergeRowStartIndex);
                    targetRowTo = targerMergeRowStartIndex + (sourceRegion.LastRow - sourceMergeRowStartIndex);
                    CellRangeAddress newRegion = sourceRegion.Copy();
                    newRegion.FirstRow = targetRowFrom;
                    newRegion.FirstColumn = sourceRegion.FirstColumn;
                    newRegion.LastRow = targetRowTo;
                    newRegion.LastColumn = sourceRegion.LastColumn;
                    sheet.AddMergedRegion(newRegion);
                }
            }
        }

        public void CopyCellValue(ICell sourceCell, ICell targetCell)
        {
            targetCell.CellStyle = sourceCell.CellStyle;
            if (sourceCell.CellComment != null)
            {
                targetCell.CellComment = sourceCell.CellComment;
            }
            CellType srcCellType = sourceCell.CellType;
            targetCell.SetCellType(srcCellType);
            switch (srcCellType)
            {
                case CellType.Numeric:
                    string value;
                    double dateValue = sourceCell.NumericCellValue;
                    ICellStyle cellStyle = sourceCell.CellStyle;
                    short dataFormat = cellStyle.DataFormat;
                    if (DateUtil.IsCellDateFormatted(sourceCell))
                    {
                        value = getDateValue(dataFormat, cellStyle.GetDataFormatString(), dateValue);
                    }
                    else
                    {
                        if (String.Equals("General", cellStyle.GetDataFormatString(), StringComparison.CurrentCultureIgnoreCase))
                        {
                            DecimalFormat format = new DecimalFormat("#");
                            value = format.Format(dateValue);
                        }
                        else
                        {
                            value = NumberToTextConverter.ToText(dateValue);
                        }
                    }
                    targetCell.SetCellValue(value);
                    break;
                //short format = sourceCell.CellStyle.DataFormat;
                ////对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理***14/31/57/58日期20/32时间
                //if (format == 14 || format == 31 || format == 57 || format == 58 || format == 20 || format == 32)
                //    targetCell.SetCellValue(sourceCell.DateCellValue);
                //else
                //    targetCell.SetCellValue(sourceCell.NumericCellValue);
                //break;
                case CellType.String:
                    targetCell.SetCellValue(sourceCell.RichStringCellValue);
                    break;
                case CellType.Formula:
                    targetCell.SetCellFormula(sourceCell.CellFormula);
                    break;
                case CellType.Blank:
                    targetCell.SetCellValue("");
                    break;
                case CellType.Boolean:
                    targetCell.SetCellValue(sourceCell.BooleanCellValue);
                    break;
                case CellType.Error:
                    targetCell.SetCellErrorValue(sourceCell.ErrorCellValue);
                    break;
                default:
                    break;
            }
        }

        /**
     * 得到date单元格格式的值
     *
     * @param dataFormat
     * @param dataFormatString
     * @param dateValue
     * @return
     */
        public String getDateValue(short dataFormat, String dataFormatString, double dateValue)
        {
            DateTime date = DateUtil.GetJavaDate(dateValue);
            /**
             * 年月日时分秒
             */
            if (EXCEL_FORMAT_INDEX_DATE_NYRSFM_STRING.Contains(dataFormatString))
            {
                return date.ToString(COMMON_DATE_FORMAT);
            }
            /**
             * 年月日
             */
            if (EXCEL_FORMAT_INDEX_DATE_NYR_STRING.Contains(dataFormatString))
            {
                return date.ToString(COMMON_DATE_FORMAT_NYR);
            }
            /**
             * 年月
             */
            if (EXCEL_FORMAT_INDEX_DATE_NY_STRING.Contains(dataFormatString) || EXCEL_FORMAT_INDEX_DATA_EXACT_NY.Equals(dataFormat))
            {
                return date.ToString(COMMON_DATE_FORMAT_NY);
            }
            /**
             * 月日
             */
            if (EXCEL_FORMAT_INDEX_DATE_YR_STRING.Contains(dataFormatString) || EXCEL_FORMAT_INDEX_DATA_EXACT_YR.Equals(dataFormat))
            {
                return date.ToString(COMMON_DATE_FORMAT_YR);
            }
            /**
             * 月
             */
            if (EXCEL_FORMAT_INDEX_DATE_Y_STRING.Contains(dataFormatString))
            {
                return date.ToString(COMMON_DATE_FORMAT_Y);
            }
            /**
             * 星期X
             */
            if (EXCEL_FORMAT_INDEX_DATE_XQ_STRING.Contains(dataFormatString))
            {
                return COMMON_DATE_FORMAT_XQ + dateToWeek(date);
            }
            /**
             * 周X
             */
            if (EXCEL_FORMAT_INDEX_DATE_Z_STRING.Contains(dataFormatString))
            {
                return COMMON_DATE_FORMAT_Z + dateToWeek(date);
            }
            /**
             * 时间格式
             */
            if (EXCEL_FORMAT_INDEX_TIME_STRING.Contains(dataFormatString) || EXCEL_FORMAT_INDEX_TIME_EXACT.Contains(dataFormat))
            {
                return date.ToString(COMMON_TIME_FORMAT);
            }
            /**
             * 单元格为其他未覆盖到的类型
             */
            if (DateUtil.IsADateFormat(dataFormat, dataFormatString))
            {
                return dateValue.ToString(COMMON_TIME_FORMAT);
            }

            return null;
        }

        /**
     * 日期转星期
     *
     * @param date
     * @return
     */
        private String dateToWeek(DateTime date)
        {
            if (date == null)
            {
                return "";
            }
            // 指示一个星期中的某天。
            int w = Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"));
            if (w < 0)
            {
                w = 0;
            }
            return WEEK_DAYS[w];
        }
    }
}
