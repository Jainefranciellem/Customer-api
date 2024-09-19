# Etapa de build
FROM node:18-alpine AS build-env
WORKDIR /app

# Instalar dependências
COPY package*.json ./
RUN npm install

# Copiar os arquivos do projeto e rodar o build
COPY . .
RUN npm run build --prod

# Etapa de servidor Nginx
FROM nginx:alpine
COPY --from=build-env /app/dist/customer-crud-app /usr/share/nginx/html

# Expor a porta usada pelo Angular (via Nginx)
EXPOSE 80
