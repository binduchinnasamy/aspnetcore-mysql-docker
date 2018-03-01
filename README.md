### ASP.NET Core Web App with MySQL DB in Docker Container

A super simple ASP.NET Core web application uses MySQL DB with Docker Container support. Both the Web Applicaiton and the MySQL DB runs in container.

Take a look at the docker-composer.yml file for more details

###### Points to note in this solution

1. MySQL DB uses a volume which is pointing to a folder in host. So the MySQL DB data persisted outside of the container
2. Sample DB http://downloads.mysql.com/docs/sakila-db.zip can loaded into mysql DB using the phpmyadmin website
3. Phpmyadmin web application can be used to connect to mySQL DB to bulk create tables (from the above link)

Docker Compose File

```
version: '3'

services:
    db:
        image: mysql
        ports: 
            - "3306:3306"
        environment:
          MYSQL_ROOT_PASSWORD: bindu123
        volumes:
        #Note that this is for Windows.
            - //C/Work/Dockershared/mysql:/var/lib/mysql   
        networks:
            - default
   
    corewebappsimple:
        image: corewebappsimple
        build:
          context: .
          dockerfile: CoreWebAppSimple/Dockerfile
        links:
          - db:db
        ports:
          - 8001:80
        restart: always

    phpmyadmin:
          image: phpmyadmin/phpmyadmin
          links: 
              - db:db
          ports:
              - 8000:80
          environment:
              MYSQL_ROOT_PASSWORD: bindu123
      

```
