# ifx-hogwarts-access-mngr
Technical test to company DataIfx with technology .Net Core 3.0 +

### Install dataBase docker.
##### Download image docker sqlServer
* Execute next command
	```sh
	- sudo docker pull mcr.microsoft.com/mssql/server:2019-latest
	```
* Run image and configure
	```sh
	- docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=sqlServer123" -p 1433:1433 --name (name) -h (name) -d mcr.microsoft.com/mssql/server:2019-latest
	```
* Create dataBase
    ```sh
    - sudo docker exec -it sql1 "bash"
    - /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "<YourNewStrong@Passw0rd>"
    ```
    ```sql
    CREATE DATABASE dbformatqa;
    ```

##### Download image docker mysqlServer
* Execute next command 
	```sh
	- docker pull mysql/mysql-server:version
	```
* Run image and configure
	```sh
	- docker run --name=(name) -d -p 3306:3306 mysql/mysql-server:version
	```
	* Linux grep and Windows findstr.
		```sh
		docker logs (name) 2>&1 | (findstr || grep) GENERATED
		```
	* Session docker mysql image
		```sh
		docker exec -it (name) mysql -uroot -p
		```
	* Create dataBase
	    ```sql
	    CREATE DATABASE dbformatqa;
	    ```
	* Change password
		```sh
		- ALTER USER 'root'@'localhost' IDENTIFIED BY 'server123*';
		- CREATE USER 'root'@'%' IDENTIFIED BY 'dbformatqa%';
		- GRANT ALL PRIVILEGES ON dbformatqa.* TO 'root'@'%';
		```

### Install WebApi .Net Core 3.1 Clean Architecture
Once downloaded the application, we execute the following command in src
```sh
 cd .\src\hogwartsAccess.API\
 docker build -t hogwarts src\hogwartsAccess.API\.
 docker run -d -p (port):(port) --name ifx-hogwarts-access-mngr hogwarts
```
