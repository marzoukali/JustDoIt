import { TodoCategory } from "./todo-category";

export interface TodoItem {
    id: string;
    title: string;
    createdAt: string;
    dueAt: string;
    isComplete: boolean;
    creatorId: string;
    categoryId: number;
    categoryName: string;
}