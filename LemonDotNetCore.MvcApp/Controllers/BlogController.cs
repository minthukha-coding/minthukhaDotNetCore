using LemonDotNetCore.MvcApp.Models;
using LemonDotNetCore.MVCApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        public readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [ActionName("List")]
        public async Task<IActionResult> List(int pageNo = 1, int pageSize = 10)
        {
            var query = _appDbContext.Blogs
                //.Where(x => x.DeleteFlag == false);
                .AsNoTracking()
                .OrderByDescending(x => x.Blog_Id);

            var lst = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();
            var rowCount = await query.CountAsync();

            var pageCount = rowCount / pageSize;
            if (rowCount % pageSize > 0)
            {
                pageCount++;
            }

            BlogResponseModel model = new BlogResponseModel()
            {
                Data = lst,
                //PageSetting = new PageSettingModel()
                //{
                //    PageNo = pageNo,
                //    PageSize = pageSize,
                //    PageCount = pageCount,
                //    PageRowCount = rowCount,
                //}
                PageSetting = new PageSettingModel(pageNo, pageSize, pageCount, rowCount, "/Blog/List")
            };

            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            var lst = await _appDbContext.Blogs
                .OrderByDescending(x => x.Blog_Id)
                .ToListAsync();
            return View(lst);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(BlogDataModel requestModel)
        {
            await _appDbContext.Blogs.AddAsync(requestModel);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {

            var item = await _appDbContext.Blogs.FirstOrDefaultAsync(x => x.Blog_Id == id);
            if (item is null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<IActionResult> Update(int id, BlogDataModel requestModel)
        {
            var item = await _appDbContext.Blogs.FirstOrDefaultAsync(x => x.Blog_Id == id);
            if (item is null)
            {
                return RedirectToAction("Index");
            }

            item.Blog_Title = requestModel.Blog_Title;
            item.Blog_Author = requestModel.Blog_Author;
            item.Blog_Content = requestModel.Blog_Content;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var item = await _appDbContext.Blogs.FirstOrDefaultAsync(x => x.Blog_Id == id);
            if (item is null)
            {
                return RedirectToAction("Index");
            }
            _appDbContext.Remove(item);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}