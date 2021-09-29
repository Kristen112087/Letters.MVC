using Letters.Data;
using Letters.Models;
using Letters.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letters.Services
{
    public class LetterService
    {
        private readonly Guid _userId;
        public LetterService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLetter(LetterCreate model)
        {
            var entity = new Letter()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Letters.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LetterListItem> GetLetters()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Letters.Where(l => l.OwnerId == _userId).Select(l => new LetterListItem
                {
                    LetterId = l.LetterId,
                    Title = l.Title,
                    CreatedUtc = l.CreatedUtc
                }
                );
                return query.ToArray();
            }
        }
    }
}
