using Client.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class User
    {
        private Guid Username;
        private Rectangle_Object LastEvent;

        public Guid Username1 { get => Username; set => Username = value; }
        public Rectangle_Object LastEvent1 { get => LastEvent; set => LastEvent = value; }

        public User (Guid username)
        {
            this.Username = username;
        }

        public Rectangle_Object GetLastEvent()
        {
            return this.LastEvent;
        }

        public void SetLastEvent(Rectangle_Object ev)
        {
            this.LastEvent = ev;
        }
    }
}
