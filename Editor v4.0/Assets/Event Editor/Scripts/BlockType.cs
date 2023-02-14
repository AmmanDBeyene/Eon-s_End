using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Event_Editor.Scripts
{
    [Serializable]
    public enum BlockType
    {
        Command, 
        Condition
    }

    public enum DotType
    {
        Output, 
        Input
    }

    [Serializable]
    public enum PipeType
    {
        None,
        Condition,
        Command
    }
}
