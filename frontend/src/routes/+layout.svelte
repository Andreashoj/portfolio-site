<script lang="ts">
	import '../app.css';
    import Header from "$components/layout/Header.svelte";
    import Footer from "$components/layout/Footer.svelte";
	let { children } = $props();
</script>

<svelte:head>
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Spectral:ital,wght@0,200;0,300;0,400;0,500;0,600;0,700;0,800;1,200;1,300;1,400;1,500;1,600;1,700;1,800&display=swap" rel="stylesheet">
</svelte:head>

<Header />
<span class="font-custom">MY TEXT</span>
{@render children()}
<Footer />