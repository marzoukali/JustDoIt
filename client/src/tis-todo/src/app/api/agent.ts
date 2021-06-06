import axios, {AxiosError, AxiosResponse} from 'axios';
import { toast } from 'react-toastify';
import { TodoItem } from '../models/todo-item';
import {history} from '../../index'
import { store } from '../stores/store';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}
axios.defaults.baseURL = 'https://localhost:5301/api';

axios.interceptors.response.use(async res => {
        await sleep(1000);
        return res;
}, (error: AxiosError) => {
 const{data, status} = error.response!;
 switch(status){
     case 400:
         if(data.errors){
             const modelStateErrors = [];
             for(const key in data.errors){
                 if(data.errors[key]){
                     modelStateErrors.push(data.errors[key])
                 }
             }

             throw modelStateErrors.flat();

         }else{
            toast.error(data);
         }
         break;
     case 401:
         toast.error('unauthorize');
         break;
    case 404:
        history.push('/not-found')
        toast.error('not found');
        break;
    case 500:
        store.commonStore.setServerError(data);
        history.push('/server-error');
        break;
 }
 return Promise.reject(error);
})

const responseBody = <T> (response: AxiosResponse<T>) => response.data;

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const TodoItems = {
    list: () => requests.get<TodoItem[]>('/UserTodos'),
    details: (id: string) => requests.get<TodoItem>(`/UserTodos/${id}`),
    create: (todoItem: TodoItem) => requests.post<void>('/UserTodos', todoItem),
    update: (todoItem: TodoItem) => requests.put<void>(`/UserTodos/${todoItem.id}`, todoItem),
    delete: (id: string) => requests.delete<void>(`/UserTodos/${id}`),
}

const agent = {
    TodoItems
}

export default agent;