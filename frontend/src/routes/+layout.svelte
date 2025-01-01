<script lang="ts">
	import '../app.css';
	import Navbar from '$components/layout/Navbar.svelte';
	import Footer from '$components/layout/Footer.svelte';
	import { api } from '$lib/api';
	import { user } from '$lib/stores/auth';
	let { children } = $props();

	function handleGoogleLogin() {
		const returnUrl = window.location.href;
		window.location.href = `http://localhost:5000/auth/google-login?returnUrl=${encodeURIComponent(returnUrl)}`;
	}
</script>

<svelte:head>
	<link rel="preconnect" href="https://fonts.googleapis.com" />
	<link rel="preconnect" href="https://fonts.gstatic.com" />
	<link
		href="https://fonts.googleapis.com/css2?family=Spectral:ital,wght@0,200;0,300;0,400;0,500;0,600;0,700;0,800;1,200;1,300;1,400;1,500;1,600;1,700;1,800&display=swap"
	/>
	{#if import.meta.env.PROD}
		<script
			defer
			src="https://cloud.umami.is/script.js"
			data-website-id="67243811-cbc8-450c-812b-21a115dd41f0"
		></script>
	{/if}
</svelte:head>

<div class="flex min-h-screen flex-col">
	<Navbar />

	<main class="flex flex-1 justify-center bg-slate-100 px-5 py-16 dark:bg-slate-900 xl:px-0">
		<div class="w-full max-w-7xl">
			{@render children()}
		</div>
	</main>

	{$user?.email}
	{$user?.username}
	<button on:click={handleGoogleLogin}>Login</button>
	<Footer />
</div>
