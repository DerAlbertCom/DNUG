using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Aperea.Data;
using Aperea.Infrastructure.Mappings;
using UserGroup.Api.Models;
using UserGroup.Entities;

namespace UserGroup.Api.Controllers
{
    [Authorize(Roles = UserGroup.Security.Roles.Administrator)]
    public class MeetingsController : ApiController
    {
        readonly IRepository<Meeting> repository;

        public MeetingsController(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<DisplayMeetingLineModel> GetAllMeetings()
        {
            var list = repository.Entities.OrderByDescending(m => m.StartTime).ToList();
            return list.MapTo<DisplayMeetingLineModel>();
        }

        [HttpGet]
        public DisplayMeetingLineModel GetMeeting(int id)
        {
            return GetSingleMeeting(id).MapTo<DisplayMeetingLineModel>();
        }

        Meeting GetSingleMeeting(int id)
        {
            return repository
                .Include(m => m.Location)
                .Single(m => m.Id == id);
        }
    }
}