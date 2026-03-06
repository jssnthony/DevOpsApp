using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ProjectsTasks
{
    public enum EnumProjectTasksStatus
    {
        IsDeleted = -1,
        Idea = 0,
        ToDo = 1,
        InProgress = 2,
        Done = 3
    }
}
