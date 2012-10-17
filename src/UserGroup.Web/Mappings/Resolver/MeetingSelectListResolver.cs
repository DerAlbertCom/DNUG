using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using UserGroup.Data;
using UserGroup.Entities;

namespace UserGroup.Web.Mappings.Resolver
{
    public class MeetingSelectListResolver : ValueResolver<IHasMeeting, IEnumerable<SelectListItem>>
    {
        readonly IRepository<Meeting> repository;

        public MeetingSelectListResolver(IRepository<Meeting> repository)
        {
            this.repository = repository;
        }

        protected override IEnumerable<SelectListItem> ResolveCore(IHasMeeting source)
        {
            var query = from l in repository.Entities
                        orderby l.StartTime descending 
                        select new { Text = l.Title, Value = l.Id };
            var empty = new  { Text = "<auswählen>", Value = 0 };
            return new SelectList(new[] { empty }.Concat(query.ToList()),"Value","Text", GetSelectedValue(source));
        }

        static int GetSelectedValue(IHasMeeting source)
        {
            var meetingId = 0;
            if (source!=null && source.Meeting != null)
                meetingId = source.Meeting.Id;
            return meetingId;
        }
    }
}