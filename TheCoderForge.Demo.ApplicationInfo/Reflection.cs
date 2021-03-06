using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCoderForge.Demo.ApplicationInfo
{
   public static class Reflection
    {

        
        public static PropertyInfo FindProperty(object container, string propertyName)
        {

            Type containerType = container.GetType();

            if (containerType == null) throw new NullReferenceException(nameof(containerType));

            PropertyInfo[] properties = containerType.GetProperties();

            foreach (PropertyInfo property in properties) //TODO replace with linq? will it be better?
                if (property.Name == propertyName)
                    return property;


            Debugger.Break();

            throw new Exception(); //TODO improve exception
        }

        public static FieldInfo FindField(object container, string fieldName)
        {
     
            Type containerType = container.GetType();

            if (containerType == null) throw new NullReferenceException(nameof(containerType));

            FieldInfo[] fields = containerType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo fieldInfo in fields) //TODO replace with linq? will it be better?
                if (fieldInfo.Name == fieldName)
                    return fieldInfo;

            Debugger.Break();

            throw new Exception(); //TODO improve exception
        }

        public static Control FindControl(Control sourceControl, string controlName)
        {
            PropertyInfo controlsPropertyInfo = sourceControl.GetType().GetProperty("Controls");
            Control.ControlCollection controlCollection = (Control.ControlCollection) controlsPropertyInfo.GetValue(sourceControl, null);
            foreach (Control control in controlCollection) //TODO replace with linq? will it be better?
            {
                Type controlType = control.GetType();
                string sName = controlType.Name;

                if (sName == controlName) return control;
            }

            throw new Exception(); //TODO improve teh exception
        }


    }
}
