using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace RestApiCRUD.Mappers
{
    public class ResponseMapper{
        public static Hashtable map(string statusText, object responseObj, string message)
        {
            Hashtable map = new Hashtable();

            map["status"] = statusText;
            map["message"] = message;
            map["result"] = responseObj;
            return new Hashtable(map);
           
          }

    }

}
