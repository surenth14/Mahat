#!/bin/bash
ROOTDIRECTORY=$(cd -P -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd -P)
cd "$ROOTDIRECTORY"/Marketplacenew.Models
echo "The current directory is : Expecting Model folder"
pwd
echo cma@2020# | sudo -S  dotnet build
cd "$ROOTDIRECTORY"/Marketplacenew.DAL
echo "The current directory is : Expecting DAL folder"
pwd
echo cma@2020# | sudo -S  dotnet build
cd "$ROOTDIRECTORY"/
echo cma@2020# | sudo -S  rm -f "$ROOTDIRECTORY"/Marketplacenew.sln
echo cma@2020# | sudo -S  dotnet new sln --name Marketplacenew
echo cma@2020# | sudo -S  dotnet sln add "$ROOTDIRECTORY"/Marketplacenew.Models/Marketplacenew.Models.csproj
echo cma@2020# | sudo -S  dotnet sln add "$ROOTDIRECTORY"/Marketplacenew.DAL/Marketplacenew.DAL.csproj



                    cd "$ROOTDIRECTORY"/MarketplacenewWebApi
                    echo cma@2020# | sudo -S  dotnet build
                    echo cma@2020# | sudo -S  dotnet publish -o "$ROOTDIRECTORY"/Publish/WebApi
cd "$ROOTDIRECTORY"
                cd "$ROOTDIRECTORY"/Admin
                echo cma@2020# | sudo -S  dotnet build
                echo cma@2020# | sudo -S  dotnet publish -o "$ROOTDIRECTORY"/Publish/Admin
                echo cma@2020# | sudo -S  mkdir "$ROOTDIRECTORY"/Publish/Admin/wwwroot/uploads
                echo cma@2020# | sudo -S  cp /home/ubuntu/Automaton/AutomatonClient/wwwroot/BackupFiles/Marketplacenew/AdminUploads/*.* "$ROOTDIRECTORY"/Publish/Admin/wwwroot/uploads


echo "Setting up the Publish Evnrionment"
                        cd /home/ubuntu/Automaton/AutomatonClient/wwwroot/PublishedFiles
                        echo cma@2020# | sudo -S  chown -R ubuntu Marketplacenew
                        cd "$ROOTDIRECTORY"
                        echo cma@2020# | sudo -S  rm -f /etc/nginx/sites-enabled/tdevstaging
                        echo cma@2020# | sudo -S  rm -f /etc/supervisor/conf.d/MarketplacenewWebApi.conf
                        echo cma@2020# | sudo -S  rm -f /etc/supervisor/conf.d/MarketplacenewClient.conf
                        echo cma@2020# | sudo -S  rm -f /etc/supervisor/conf.d/MarketplacenewAdmin.conf
                        echo cma@2020# | sudo -S  cp "$ROOTDIRECTORY"/PublishRequisites/*.conf /etc/supervisor/conf.d/
                        echo cma@2020# | sudo -S  cp "$ROOTDIRECTORY"/PublishRequisites/tdevstaging /etc/nginx/sites-enabled/
                        echo cma@2020# | sudo -S  supervisorctl reread
                        echo cma@2020# | sudo -S  supervisorctl update
                        echo cma@2020# | sudo -S  supervisorctl restart MarketplacenewWebApi
                        echo cma@2020# | sudo -S  supervisorctl restart MarketplacenewClient
                        echo cma@2020# | sudo -S  supervisorctl restart MarketplacenewAdmin 
                        echo cma@2020# | sudo -S  service nginx reload
curl -v --header "Connection: keep-alive" "https://tdev-stg.craftmyapp.in/ContactUs/sentPublishedNotification?projectid=c02cf5af-bd00-45c9-a77d-e6238556cf26"
sudo -s /home/ubuntu/Automaton/AutomatonClient/wwwroot/git.sh Marketplacenew "2025-05-06 11:28" https://tdevstaging:glpat-6UnzCv8oG6mf9SUkn71M@devgit.craftmyapp.in/tdevstaging/Marketplacenew tdevstaging glpat-6UnzCv8oG6mf9SUkn71M

