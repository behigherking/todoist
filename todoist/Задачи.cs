//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace todoist
{
    using System;
    using System.Collections.Generic;
    
    public partial class Задачи
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Задачи()
        {
            this.Комментарии = new HashSet<Комментарии>();
        }
    
        public int ID { get; set; }
        public string Название { get; set; }
        public string Описание { get; set; }
        public string Статус { get; set; }
        public Nullable<int> ID_Проекта { get; set; }
        public Nullable<int> ID_Пользователя { get; set; }
        public Nullable<System.DateTime> Дата_создания { get; set; }
    
        public virtual Пользователи Пользователи { get; set; }
        public virtual Проекты Проекты { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Комментарии> Комментарии { get; set; }
    }
}
