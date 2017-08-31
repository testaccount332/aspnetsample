FROM microsoft/aspnetcore-build:1.1.2-jessie AS build-env
WORKDIR /usr/src/app

# copy everything, restore as distinct layers and publish
COPY . /usr/src/app
RUN dotnet restore
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/aspnetcore:1.1.2-jessie
WORKDIR /usr/src/app

# Set local time to Australia/Sydney
ENV TZ Australia/Sydney
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

COPY --from=build-env /usr/src/app/out .


EXPOSE 80 3000

ENTRYPOINT ["dotnet", "aspapp2.dll"]