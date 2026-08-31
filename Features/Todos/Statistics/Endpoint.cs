using Infrastructure.Storage;

namespace Features.Statistics;                                                                                                                                       
                                                                                                                                                                         
    public static class Endpoint                                                                                                                                         
    {                                                                                                                                                                    
        public static void MapGetStatistics(this IEndpointRouteBuilder app)                                                                                              
        {                                                                                                                                                                
            app.MapGet("/statistics", (ITodoStore store) =>                                                                                                              
            {                                                                                                                                                            
                var stats = store.GetStatistics();                                                                                                                       
                return Results.Ok(stats);                                                                                                                                
            });                                                                                                                                                          
        }                                                                                                                                                                
    }                