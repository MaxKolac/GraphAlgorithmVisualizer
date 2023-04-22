using System;

namespace GraphAlgorithmVisualizer.Visualization
{
    /// <summary>
    /// Interface implemented by objects that appear on the main Canvas and can be interacted with, moved around and such.
    /// </summary>
    internal interface ISelectable
    {
        void DrawSelectedOutline();
        void FollowCursow();
    }
}
