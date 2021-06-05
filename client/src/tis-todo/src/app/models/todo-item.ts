import { TodoCategory } from "./todo-category";

export interface TodoItem {
    id: string;
    title: string;
    createdAt: Date;
    dueAt: Date;
    isComplete: boolean;
    creatorId: string;
    categoryId: number;
    category: TodoCategory;
}