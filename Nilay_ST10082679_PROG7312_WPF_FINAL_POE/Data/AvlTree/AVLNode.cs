using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilay_ST10082679_PROG7312_WPF_FINAL_POE
{
    public class AVLNode
    {
        public ServiceRequest Data { get; set; }
        public AVLNode Left { get; set; }
        public AVLNode Right { get; set; }
        public int Height { get; set; }
        //--------------------------------------------------------------------------------------//
        // Constructor
        public AVLNode(ServiceRequest data)
        {
            Data = data;
            Left = null;
            Right = null;
            Height = 1;
        }
    }
}
//---------------------------------End of FIle-----------------------------------------------------//