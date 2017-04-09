using LinusForumTips.Extra_Classes.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinusForumTips.Extra_Classes.Exceptions
{
    class NoSuchSettingException : Exception
    {

        Config c = new Config();

        public NoSuchSettingException(string message) : base(message)
        {

        }

        //The exception basicly solves itself
        public NoSuchSettingException(string message, string key, object obj) : base(message)
        {
            c.addDefault(key, obj);
        }

        public NoSuchSettingException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
