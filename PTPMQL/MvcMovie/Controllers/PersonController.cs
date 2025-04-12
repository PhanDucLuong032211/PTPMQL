using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore; 
using MvcMovie.Data;
using MvcMovie.Models.Process;
using System.Data;
using System.Xml;
using OfficeOpenXml;
namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();
        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Upload()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Upload(IFormFile file)
{
    if (file != null)
    {
        string fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension != ".xls" && fileExtension != ".xlsx")
        {
            ModelState.AddModelError("", "Please choose excel file to upload!");
        }
        else
        {
            // Rename file when upload to server
            var fileName = DateTime.Now.ToShortTimeString().Replace(":", "") + fileExtension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", fileName);
            var fileLocation = new FileInfo(filePath).ToString();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                // Save file to server
                await file.CopyToAsync(stream);
                var dt = _excelProcess.ExcelToDataTable(fileLocation);

// Duyệt từng dòng trong DataTable
for (int i = 0; i < dt.Rows.Count; i++)
{
    // Tạo đối tượng Person mới
    var ps = new Person();

    // Gán giá trị từ Excel vào các thuộc tính
    ps.PersonId = dt.Rows[i][0].ToString();
    ps.FullName = dt.Rows[i][1].ToString();
    ps.Address = dt.Rows[i][2].ToString();
    ps.Email = dt.Rows[i][3].ToString();

    // Thêm đối tượng vào context
    _context.Add(ps);
}

// Lưu các thay đổi vào database
await _context.SaveChangesAsync();

// Chuyển hướng về Index
return RedirectToAction(nameof(Index));
            }
        }
    }

    return View();
}
    
        public async Task<IActionResult> Index()
        {
            var model=await _context.Persons.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FullName,Address,Email")] Person person)
        {
            if(ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if(id==null || _context.Persons==null)
            {
                return NotFound();
            }
            var person=await _context.Persons.FindAsync(id);
            if(person==null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,[Bind("PersonId,FullName,Address,Email")] Person person)
        {
            if(id!=person.PersonId)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if(id==null)
            {
                return NotFound();
            }
            var person=await _context.Persons.FirstOrDefaultAsync(m=>m.PersonId==id);
            if(person==null)
            {
                return NotFound();
            }
    
            return View(person);
        }
        [HttpPost,ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if(_context.Persons==null)
            {
                return Problem("khong co du lieu");

            }
            var person=await _context.Persons.FindAsync(id);
            if(person!=null)
            {
                _context.Persons.Remove(person);
            }
           
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PersonExists(string id)
        {
            return (_context.Persons?.Any(e=>e.PersonId==id)).GetValueOrDefault();
        }

        public IActionResult Download()
    {
        // Cấu hình license để tránh lỗi
      

        var fileName = "DanhSachNguoiDung_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

        using (ExcelPackage excelPackage = new ExcelPackage())
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");

            // Header
            worksheet.Cells["A1"].Value = "PersonID";
            worksheet.Cells["B1"].Value = "FullName";
            worksheet.Cells["C1"].Value = "Address";
            worksheet.Cells["D1"].Value = "Email";
            // Lấy dữ liệu từ database
            var personList = _context.Persons.ToList();

            // Đổ dữ liệu vào từ hàng 2
            worksheet.Cells["A2"].LoadFromCollection(personList, false);

            // Xuất ra stream
            var stream = new MemoryStream(excelPackage.GetAsByteArray());

            // Trả về file excel
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }}
     
    }
}