1. Install linux
2. Install 3rd party tool for windows<->linux communication
	-putty  (ssh client)
	-WIN SCP (scp protocol client for sending files between linux<->windows)
3. Install PostgreSQL on linux
	-set listen_addresses in postgresql.conf to listen_addresses = '*'
	-edit PG_HBA.conf file
4. Add folder and priviliges for compiled app (CHMOD command)
5. Install several tools on linux:
	net core SDK 2.2: https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/sdk-current
	nginx: sudo apt-get install nginx
6. Edit file /etc/nginx/sites-available/default
	server {
    		listen 80;
  	location / {
    		 proxy_pass http://localhost:5000;
        	proxy_http_version 1.1;
	        proxy_set_header Upgrade $http_upgrade;
	        proxy_set_header Connection keep-alive;
	        proxy_set_header Host $host;
	        proxy_cache_bypass $http_upgrade;
    		}
	}
7. Run nginx: 
	-sudo nginx-t
	-sudo service nginx start
8. Execute command: dotnet publish on Windows
9. Copy compiled files from windows->linux using WinSCP app
10. execute: dotnet WebAPI.dll