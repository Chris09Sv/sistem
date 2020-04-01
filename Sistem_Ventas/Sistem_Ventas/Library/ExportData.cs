﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sistem_Ventas.Library
{
    public class  ExportData<T>:Controller
    {
        private HttpRequest _request;
        private List<String[]> _listData;
        private String _fileName,_table;
        private String[] _titles;
        private IHostingEnvironment _hostingEnvironment;

        public ExportData(IHostingEnvironment hostingEnvironment,HttpRequest request, List<String[]> listData,String[] titles, 
            String fileName, String table)
        {
            _table = table;
            _fileName = fileName;
            _titles = titles;
            _listData = listData;
            _request = request;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task<ActionResult> ExportExcelAsync()
        {
            string sWebRootFolder = _hostingEnvironment.WebRootPath;
            var memory = new MemoryStream();
            using (var fs=new FileStream(Path.Combine(sWebRootFolder, _fileName), FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook;
                workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet(_table);
                IRow row = excelSheet.CreateRow(0);
                for(int i=0; i < _titles.Length; i++)
                {
                    row.CreateCell(i).SetCellValue(_titles[i]);
                }
                int count = 1;

                for (int i=0; i < _listData.Count; i++)
                {
                  //  row.CreateCell(j).SetCellValue(list[j]);

                 row  =   excelSheet.CreateRow(count);
                    var list = _listData[i];

                    for (int j = 0; j < _titles.Length; j++)
                    {
                        row.CreateCell(j).SetCellValue(list[j]);

                    }
                    count++;
                }
                workbook.Write(fs);
            }
            using (var stream = new FileStream(Path.Combine(sWebRootFolder, _fileName), FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
                return File(memory,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",_fileName);
        }
    }
}