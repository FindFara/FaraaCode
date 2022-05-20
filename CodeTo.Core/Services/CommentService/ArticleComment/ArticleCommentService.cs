using CodeTo.Core.Services.LoggerServices;
using CodeTo.Core.Services.UserPanelServices;
using CodeTo.Core.ViewModel.Articles;
using CodeTo.DataEF.Context;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTo.Core.Services.CommentService.ArticleComment
{
    public class ArticleCommentService : IArticleCommentService
    {
        private readonly CodeToContext _context;
        private readonly IUserPanelService _userPanelService;
        public ArticleCommentService(CodeToContext context)
        {
            _context = context;
        }
        
        public async Task<bool> AddCommentAsync(ArticleCommentViewModel comment, string username)
        {
            try
            {
                await _context.ArticleComments.AddAsync(new Domain.Entities.Articles.ArticleComment
                {
                    Id = comment.id,
                    ArticleId = comment.ArticleId,
                    UserId = _userPanelService.GetUserIdByUserName(username),
                    CreateDate = DateTime.Now,
                    ReaedAdmin = false

                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
               
                return false;
            }
        }

        public Task<List<ArticleCommentViewModel>> GetCommentsAsync(int Articleid)
        {
            throw new NotImplementedException();
        }
    }
}
