﻿namespace Compose
{
    public interface DynamicRegister<T>
    {
		T CurrentService { get; set; }
		T SnapshotService { get; set; }
		void Register(T instance);
    }
}
