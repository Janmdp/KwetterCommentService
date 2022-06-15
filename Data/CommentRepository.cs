using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CommentRepository
    {
        private readonly CommentDbContext context;

        public CommentRepository(CommentDbContext ctx)
        {
            context = ctx;
        }

        public void CreateComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }

        public object GetCommentById(int id)
        {
            return context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public void DeleteComment(int id)
        {
            var comment = context.Comments.FirstOrDefault(c => c.Id == id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }

        public void DeleteAllByUser(int id)
        {
            var comments = context.Comments.Where(c => c.AuthorId == id).ToList();
            context.Comments.RemoveRange(comments);
            context.SaveChanges();
        }

        public object GetCommentsForPost(int id)
        {
            var comments = context.Comments.Where(c => c.PostId == id).ToList();
            return comments;
        }
    }
}
