FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore  "./aws-test/aws-test.csproj" --disable-parallel
RUN ls -a
RUN dotnet publish "./aws-test/aws-test.csproj" -c Release -o /app --no-restore

WORKDIR /source/aws-test
EXPOSE 80
EXPOSE 443
EXPOSE 7247
EXPOSE 5247
ENTRYPOINT ["dotnet", "run"]
