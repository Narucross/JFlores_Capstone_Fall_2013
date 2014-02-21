using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Listbox_Drag_and_Drop_Tests.Behavior.Implementation;

namespace Listbox_Drag_and_Drop_Tests.Behavior
{
    public class FrameworkElementDragBehavior : Behavior<FrameworkElement>, IMvvmBehavior
    {

        protected override void OnDetaching()
        {
            base.OnDetaching();
            IsMvvmParadigm = IsAssociatedObjectMvvm();
            _mouseDown = false;
            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_LeftMouseButton_Down_Handler;
            AssociatedObject.MouseLeftButtonUp -= AssociatedObject_LeftMouseButton_Up_Handler;
            AssociatedObject.MouseLeave -= AssociatedObject_MouseLeave_Handler;
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += AssociatedObject_LeftMouseButton_Down_Handler;
            AssociatedObject.MouseLeftButtonUp += AssociatedObject_LeftMouseButton_Up_Handler;
            AssociatedObject.MouseMove += AssociatedObject_MouseLeave_Handler;
        }

        private void AssociatedObject_LeftMouseButton_Down_Handler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // On click it needs to retrieve and store the AO.Datacontext
            if (IsMvvmParadigm)
            {
                var dataContext = AssociatedObject.DataContext as IMvvmDraggable;

                _mouseDown = dataContext != null;

            }
        }

        private bool _mouseDown;

        private void AssociatedObject_MouseLeave_Handler(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (_mouseDown)
            {
                DragDrop.DoDragDrop(AssociatedObject, AssociatedObject.DataContext, DragDropEffects.Copy);
            }
        }

        private void AssociatedObject_LeftMouseButton_Up_Handler(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _mouseDown = false;
        }

        #region IMvvMBehavior implementation
        public bool IsAssociatedObjectMvvm()
        {
            return AssociatedObject.DataContext is IMvvmParadigm;
        }
        private bool IsMvvmParadigm { get; set; }
        #endregion
    }//end of class
}//end of Namespace