using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isaac.Infrastracture.IoC
{
    public class ContainerRef<T> : IDisposable
        where T : class, IDisposable
    {
        protected ContainerRef(T container)
        {
            this.container = container;
        }

        public static ContainerRef<T> Current
        {
            get
            {
                if (current != null)
                    return current;

                throw new InvalidOperationException("请初始化对容器的引用！");
            }
        }

        public static T GetContainer()
        {
            if (current != null)
                return current.container;

            return null;
        }

        public static void Init(T container)
        {
            if (container != null)
            {
                lock (sychro)
                {
                    if (current == null)
                        current = new ContainerRef<T>(container);
                }
            }

            throw new ArgumentNullException("container");
        }

        public T Container { get { return container; } }

        public void Dispose()
        {
            if (container != null)
                container.Dispose();

            current = null;
        }

        private readonly T container;
        private static ContainerRef<T> current;
        private static readonly object sychro = new object();
    }
}
