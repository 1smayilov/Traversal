﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;
using System.Data;

namespace SignalRApi.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(IHubContext<VisitorHub> hubContext, Context context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("CallVisitorList", "aaaaa");
        }

        public List<VisitorChart> GetVisitorChartList()     
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();
              using(var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Query sorgu";
                command.CommandType = CommandType.Text;
                _context.Database.OpenConnection(); 
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            visitorChart.Counts.Add(reader.GetInt32(x));
                        });
                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;  
            }
        }
    }
}
 