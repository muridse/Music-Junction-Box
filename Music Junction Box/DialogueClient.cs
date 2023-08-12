using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Junction_Box.Processors;

namespace Music_Junction_Box
{
    internal class DialogueClient
    {
        private static readonly DialogueClient instance = new DialogueClient();
        private DialogueClient() 
        {
            
        }
        public void Run() 
        {
            
        }
        public static DialogueClient GetInstance()
        {
            return instance;
        }
    }
}
