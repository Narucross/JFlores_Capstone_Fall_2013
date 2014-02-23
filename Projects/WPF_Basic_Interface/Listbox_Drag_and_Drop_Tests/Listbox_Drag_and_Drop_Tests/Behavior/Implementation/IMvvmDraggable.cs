namespace Listbox_Drag_and_Drop_Tests.Behavior.Implementation
{
    /// <summary>
    /// Implementing this interface says that the class is intended to be the viewmodel for a drag operation in a mvvm application.
    /// </summary>
    public interface IMvvmDraggable : IMvvmParadigm
    {
        /// <summary>
        /// Basically if you have to remove the item as it is dragged from its source,  you call this method to allow the implementer to handle it its own way.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>false-if remove failed by exception</returns>
        bool Remove(object obj);
    }//end of interface
}//end of namespace