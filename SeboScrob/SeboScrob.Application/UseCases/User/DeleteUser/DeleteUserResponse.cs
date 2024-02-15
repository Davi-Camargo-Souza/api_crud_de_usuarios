using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Application.UseCases.User.DeleteUser
{
    public record DeleteUserResponse
    {
        public bool Success { get; set; }
    }
}
