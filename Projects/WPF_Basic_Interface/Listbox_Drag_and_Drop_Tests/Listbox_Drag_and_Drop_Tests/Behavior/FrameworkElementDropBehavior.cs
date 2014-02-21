using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Listbox_Drag_and_Drop_Tests.Behavior.Implementation;
using System.Windows.Interactivity;

namespace Listbox_Drag_and_Drop_Tests.Behavior
{
    public class FrameworkElementDropBehavior : Behavior<FrameworkElement>, IMvvmBehavior
    {
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.DragEnter -= AssociatedObject_DragEnter_Handler;
            AssociatedObject.DragOver -= AssociatedObject_DragOver_Handler;
            AssociatedObject.DragLeave -= AssociatedObject_DragLeave_Handler;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            IsMvvmParadigm = IsAssociatedObjectMvvm();
            AssociatedObject.DragEnter += AssociatedObject_DragEnter_Handler;
            AssociatedObject.DragOver += AssociatedObject_DragOver_Handler;
            AssociatedObject.DragLeave += AssociatedObject_DragLeave_Handler;
        }

        private void AssociatedObject_DragEnter_Handler(object sender, DragEventArgs e)
        {
            //ToDO what to do when you recieve a drag event

            throw new NotImplementedException();
        }

        private void AssociatedObject_DragOver_Handler(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AssociatedObject_DragLeave_Handler(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool acceptsDrop()
        {
            return AssociatedObject.DataContext is IMvvmDroppable;
        }

        #region IMvvMBehavior implementation
        public bool IsAssociatedObjectMvvm()
        {
            return AssociatedObject.DataContext is IMvvmParadigm;
        }
        private bool IsMvvmParadigm { get; set; }
        #endregion
    }
}
