using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TypesAPI.Models;

namespace TypesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypeController : ControllerBase
    {
        
        [HttpPost]
        public IEnumerable<FormattedType> Post([FromBody] Request request)
        {
            var types = request.Types;
            var formattedTypes = new List<FormattedType>();

            foreach(var type in types)
            {
                formattedTypes.Add(new FormattedType
                {
                    ID = type.ID,
                    Name = type.Name,
                    Icon = type.Icon,
                    ModuleID = type.ModuleID,
                });
            }
            
            var result = GetHierarchy(types, formattedTypes);

            return result;
        }
        private IEnumerable<FormattedType> GetHierarchy(List<Models.Type> types, List<FormattedType> formattedTypes)
        {
            var newTypes = new List<FormattedType>(formattedTypes);
            foreach(var formattedType in formattedTypes)
            {
                foreach(var type in types)
                {
                    if (type.OwnerID == formattedType.ID)
                    {
                        formattedType.Children ??= new List<FormattedType>();
                        formattedType.Children.Add(new FormattedType
                            { 
                            ID = type.ID,
                            Name = type.Name,
                            Icon = type.Icon,
                            ModuleID = type.ModuleID
                            });
                        newTypes.Remove(newTypes.FirstOrDefault(x => x.ID == type.ID));
                        foreach(var child in formattedType.Children)
                        {
                            foreach(var childType in types)
                            {
                                if (type.ID == childType.OwnerID)
                                {
                                    child.Children ??= new List<FormattedType>();
                                    child.Children.Add(new FormattedType
                                    { 
                                    ID = child.ID,
                                    Name = child.Name,
                                    Icon = child.Icon,
                                    ModuleID = child.ModuleID
                                    });
                                   newTypes.Remove(newTypes.FirstOrDefault(x => x.ID == type.ID));
                                }
                            }
                            
                        }
                    }

                }
            } 
            return newTypes;
       }

    }
}
