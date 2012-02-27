using System;
using System.Collections.Generic;
using UserGroup.Entities;

namespace UserGroup.Data.Seeders
{
    public class MeetingsSeeder
    {
        public IEnumerable<Meeting> GetMeetings()
        {
            var location = new Location
                               {
                                   Name = "Microsoft Köln",
                                   Address = {City = "Köln", ZipCode = "50676 ", Street = "Holzmarkt 2"},
                               };
            var speaker1 = new Speaker()
                               {
                                   GivenName = "Albert",
                                   LastName = "Weinert",
                                   Homepage = "http://der-albert.com"
                               };
            var speaker2 = new Speaker()
                               {
                                   GivenName = "Stefan",
                                   LastName = "Lange",
                                   Homepage = "http://st-lange.net"
                               };
            var speaker3 = new Speaker()
                               {
                                   GivenName = "Holger",
                                   LastName = "Wendel",
                                   Homepage = "https://twitter.com/levdaywalker"
                               };
            var talk1 = new Talk()
                            {
                                Title = ".NET Gadgeteer ",
                                Abstract =
                                    "Nur Lego für Große oder doch der einfache Weg des „rapid prototyping“ für Hardwarekomponenten?",
                                Description =
                                    @"In Rekordgeschwindigkeit Hardware programmieren, bauen und das ohne Lötkolben? Mit dem Microsoft .NET Gadgeteer kann man Prototypen von elektronischen Geräten entwickeln, testen und immer wieder neu erfinden und das ganz komfortabel mit dem .NET Micro Framework, C# und Visual Studio als Entwicklungsumgebung.
Mit einer ARM7-Mikroprozessor-Platine bewaffnet, wird Holger Wendel in seinem Vortrag ein paar Beispiele zur Verwendung des Gadgeteer zeigen und dabei unterschiedliche Komponenten wie Taster, LEDs , Ethernet-Schnittstelle, Kartenleser bis hin zu Display und Kamera zum Einsatz bringen."
                            };
            talk1.Speakers.Add(speaker3);

            var talk2 = new Talk()
                            {
                                Title = "Visual Studio 11 (vNext)",
                                Abstract = "Am 29. Februar erscheint die Beta Version von Visual Studio 11",
                                Description =
                                    "Wir werden einen schnellen Überblick über die wichtigstens Neuerungen geben"
                            };
            talk2.Speakers.Add(speaker2);
            talk2.Speakers.Add(speaker1);
            var meeting = new Meeting()
                              {
                                  Title = "62. User Treffen der .net user Group Köln",
                                  Group = "dnugk",
                                  Description = ".NET Gadgeteer und Visual Studio vNext",
                                  Location = location,
                                  StartTime = new DateTime(2012,03,06,19,0,0).ToUniversalTime()
                              };
            meeting.Talks.Add(talk1);
            meeting.Talks.Add(talk2);
            yield return meeting;
        }
    }
}