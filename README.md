# ClearioAPI
Backend of the web-service for online formation of orders and control over their implementation for a cleaning company.
Allows you to generate orders for cleaning the premises, receiving a list of cleaners from another api-service.
Automatically changes the status of orders and notifies if one of the cleaners did not come to work at the set time.
It is possible to change the status manually. 
</br>
</br>
Technologies of backend:
- ASP.NET WebAPI
- Entity Framework with SQLite
- Quartz for task scheduling

# UI

<h3>Main page</h3>

![image](https://user-images.githubusercontent.com/73549276/182039102-823bdb46-6561-44b2-8a93-413808552d35.png)

<h3>Order formation</h3>

![image](https://user-images.githubusercontent.com/73549276/182039145-7644d6e9-8745-4668-b090-4e1576ae9737.png)
