// src/lib/stores/auth.ts
import { writable } from 'svelte/store';
import { browser } from '$app/environment';
import { api } from '$lib/api';

interface User {
	email: string;
	username: string;
}

export const token = writable<string>(browser ? (localStorage.getItem('token') ?? '') : '');
export const user = writable<User | null>(null);

token.subscribe((value) => {
	if (browser) {
		localStorage.setItem('token', value);
	}
});

export async function getUserData() {
	try {
		const res = await api.get('/user');
		if (!res.ok) throw new Error('Failed to fetch user data');

		const userData = await res.json();
		user.set(userData);
		return userData;
	} catch (error) {
		console.error('Error fetching user data:', error);
		user.set(null);
		return null;
	}
}
