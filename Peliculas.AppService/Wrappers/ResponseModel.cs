using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public ResponseModel()
        {

        }

        public ResponseModel(T data, string message = null)
        {
            Success = true;
            Message = message;
            Data = data;

        }

        public ResponseModel(string message = null)
        {
            Success = false;
            Message = message;

        }
    }
}
