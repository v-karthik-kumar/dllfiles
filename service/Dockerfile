FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
ENV ASPNETCORE_URLS="https://+:7247;http://+:5247"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="./wildcard_get1page_com.pfx"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="get1page" 

WORKDIR /app
#COPY --from=publish /app .
COPY ./wildcard_get1page_com.pfx .



WORKDIR /source
COPY . .
COPY ./wildcard_get1page_com.pfx .
RUN dotnet restore  "./aws-test/aws-test.csproj" --disable-parallel
RUN ls -a
RUN dotnet publish "./aws-test/aws-test.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
ENV ASPNETCORE_URLS="https://+:7247;http://+:5247"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="./wildcard_get1page_com.pfx"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="get1page"
WORKDIR /app
COPY --from=build-env /app .
EXPOSE 7247
ENTRYPOINT ["dotnet", "aws-test.dll"]
