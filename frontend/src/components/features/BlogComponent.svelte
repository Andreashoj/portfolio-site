<script lang="ts">
	import { renderContent } from '$lib/sanityRenderer.js';
	import Prism from 'prismjs';
	import 'prism-themes/themes/prism-atom-dark.css';
	import 'prismjs/components/prism-typescript';
	import 'prismjs/components/prism-javascript';
	import 'prismjs/components/prism-css';
	import 'prismjs/components/prism-markup'; // for HTML
	import 'prismjs/plugins/line-numbers/prism-line-numbers.css'; // Include the CSS for line numbers
	import 'prismjs/plugins/line-numbers/prism-line-numbers.js';
	import 'prismjs/plugins/line-highlight/prism-line-highlight.css';
	import 'prismjs/plugins/line-highlight/prism-line-highlight.js';
	import { onMount } from 'svelte';

	export let content: any;
	onMount(() => {
		Prism.highlightAll();
	});
</script>

<div class="text-gray-800 dark:text-gray-200">
	{@html renderContent(content)}
</div>

<style>
	:global(pre[class*='language-']) {
		margin: 0 !important;
	}

	:global(.line-highlight) {
		background: rgba(50, 205, 86, 0.1) !important;
	}

	:global(.code-container) {
		position: relative;
	}

	:global(.code-window) {
		border-radius: 8px;
		overflow: hidden;
		background: #2d2d2d;
		margin: 1.5rem 0;
		box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1);
	}

	:global(.code-header) {
		background: #2d2d2d;
		padding: 8px 16px;
		display: flex;
		justify-content: space-between;
		align-items: center;
	}

	:global(.window-buttons) {
		display: flex;
		gap: 8px;
	}

	:global(.window-buttons span) {
		width: 12px;
		height: 12px;
		border-radius: 50%;
		display: inline-block;
	}

	:global(.close) {
		background: #ff5f56;
	}

	:global(.minimize) {
		background: #ffbd2e;
	}

	:global(.maximize) {
		background: #27c93f;
	}

	:global(.language) {
		color: #999;
		font-size: 0.9rem;
	}

	:global(.tab) {
		background: #363636;
		padding: 4px 12px;
		border-radius: 4px 4px 0 0;
		margin-left: 16px;
	}

	:global(.filename) {
		color: #fff;
		font-size: 0.9rem;
		font-family: monospace;
	}

	:global(.code-header) {
		background: #2d2d2d;
		padding: 8px 16px;
		display: flex;
		align-items: center;
	}
</style>
