import axios, {AxiosResponse} from 'axios';
import { TodoItem } from '../models/todo-item';

const sleep = (delay: number) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay)
    })
}
axios.defaults.baseURL = 'https://localhost:5301/api';

axios.interceptors.response.use(async res => {
    try {
        await sleep(1000);
        return res;
    } catch (err) {
        console.log(err);
        return await Promise.reject(err);
    }
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