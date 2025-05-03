FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:8ab06772f296ed5f541350334f15d9e2ce84ad4b3ce70c90f2e43db2752c30f6 as builder


WORKDIR /App

COPY . ./

RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "./out/LacunaRecipes.dll"]