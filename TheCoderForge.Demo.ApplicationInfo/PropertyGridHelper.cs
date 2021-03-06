using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCoderForge.Demo.ApplicationInfo
{
   public static class PropertyGridHelper
    {


        public static void SetLabelColumnWidth(ref PropertyGrid grid, int width)
        {
     
            //TODO validate width is positive.
            //zeros are allowed?

            if (grid == null) throw new ArgumentNullException("grid"); //TODO improve this exception

            FieldInfo gridViewFieldInfo = Reflection.FindField(grid, "_gridView");
            if (gridViewFieldInfo == null) throw new NullReferenceException(nameof(gridViewFieldInfo));

            Control gridViewControl = gridViewFieldInfo.GetValue(grid) as Control;
            if (gridViewControl == null) throw new NullReferenceException(nameof(gridViewControl));
            
            MethodInfo methodInfo = gridViewControl.GetType().GetMethod("MoveSplitterTo", BindingFlags.Instance | BindingFlags.NonPublic);
            if (methodInfo == null) throw new NullReferenceException(nameof(methodInfo));
            methodInfo.Invoke(gridViewControl, new object[] { width });

        }



        
        public static void ResizeDescriptionArea(ref PropertyGrid grid, int nNumLines)
        {
            if (grid == null) throw new ArgumentNullException("grid");

            //TODO validate numlines is positive

            Control control = Reflection.FindControl(grid, "DocComment");

            if (control == null) throw new NullReferenceException(nameof(control));
            Type controlType = control.GetType();

            if (controlType == null) throw new NullReferenceException(nameof(controlType));

            PropertyInfo propertyInfo = controlType.GetProperty("Lines");

            if (propertyInfo == null) throw new NullReferenceException(nameof(propertyInfo));

            propertyInfo.SetValue(control, nNumLines, null);

            FieldInfo fieldInfo = controlType.BaseType.GetField("userSized", BindingFlags.Instance | BindingFlags.NonPublic);

            if (fieldInfo == null) throw new NullReferenceException(nameof(fieldInfo));

            fieldInfo.SetValue(control, true);
        }


    }
}
