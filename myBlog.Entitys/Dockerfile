FROM microsoft/dotnet:231-aspnetcore-runtime AS base
WORKDIR /app
COPY ./publish .
ENTRYPOINT ["dotnet", "myBlog.Entitys.dll"]