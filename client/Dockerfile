FROM node:18.16.1-alpine

WORKDIR /usr/src/app

COPY client/package*.json ./

RUN npm install

COPY client/ .

EXPOSE 3000

CMD ["npm","start"]