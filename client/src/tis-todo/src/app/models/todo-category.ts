import { TodoItem } from "./todo-item";

export interface TodoCategory {
    id: number;
    title: string;
    description: string;
    creatorId: string;
    todos: TodoItem[];
}
