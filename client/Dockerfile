FROM node:18.16.1-alpine

WORKDIR /usr/src/app

COPY client/package*.json ./

RUN npm install

COPY client/ .
COPY client/config.json ./src/

EXPOSE 3000

CMD ["npm","start"]