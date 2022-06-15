using Data;
using Models;
using System;

namespace Logic
{
    public class CommentLogic
    {
        private readonly CommentRepository repo;

        public CommentLogic(CommentDbContext ctx)
        {
            repo = new CommentRepository(ctx);
        }

        public void CreateComment(Comment comment)
        {
            repo.CreateComment(comment);
        }

        public object GetCommentById(int id)
        {
           return repo.GetCommentById(id);
        }

        public void DeleteComment(int id)
        {
            repo.DeleteComment(id);
        }

        public object GetCommentsForPost(int id)
        {
            return repo.GetCommentsForPost(id);
        }

        public void DeleteAllByUser(int id)
        {
            repo.DeleteAllByUser(id);
        }
    }
}
